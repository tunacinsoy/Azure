using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

    namespace texttospeech
    {
        class Program
        {
            public static async Task SynthesisToSpeakerAsync()
            {
                // Creates an instance of a speech config with specified subscription key and service region.
                // Replace with your own subscription key and service region (e.g., "westus").
                // The default language is "en-us".
                var config = SpeechConfig.FromSubscription("04e3c263e2ea49da9785cfde16591fed", "westeurope");

                // uncomment this line to change the voice used for synthesis
                 config.SpeechSynthesisVoiceName = "en-CA-Linda";

                // Creates a speech synthesizer using the default speaker as audio output.
                using (var synthesizer = new SpeechSynthesizer(config))
                {
                    // Prompt for text input from the console
                    Console.WriteLine("Type some text that you want to speak...");
                    Console.Write("> ");

                    // read the text string from the console input
                    string text = Console.ReadLine();

                    // Call the SpeakTextAsync method on the SpeechSynthesizer object
                    // we are using an asynchronous call with the await keyword
                    // passing in the text string input from the console
                    using (var result = await synthesizer.SpeakTextAsync(text))
                    {
                        if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                        {
                            Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                        }
                        else if (result.Reason == ResultReason.Canceled)
                        {
                            var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                            Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                            if (cancellation.Reason == CancellationReason.Error)
                            {
                                Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                                Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                                Console.WriteLine($"CANCELED: Did you update the subscription info?");
                            }
                        }
                    }

                    // This is to give some time for the speaker to finish playing back the audio
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }

            static async Task Main()
            {
                await SynthesisToSpeakerAsync();
            }
        }
    }