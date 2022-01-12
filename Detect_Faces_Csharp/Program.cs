/*
    This program consumes Azure's Face API and returns the statistics of sample images.
    Author: Tuna Cinsoy
    Last Modified: 26.02.21
*/

using System;
using static System.Environment;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace Detect_Faces_Csharp
{
    class Program
    {
         public static FaceClient GetFaceClient()
        {
            var serviceEndpoint = GetEnvironmentVariable("COGNITIVE_SERVICE_ENDPOINT");
            var subscriptionKey = GetEnvironmentVariable("COGNITIVE_SERVICE_KEY");
            var credential = new ApiKeyServiceClientCredentials(subscriptionKey);
            return new FaceClient(credential) { Endpoint = serviceEndpoint };
        }
        static async Task Main(string[] args)
        {
            var faceClient = GetFaceClient();

            var url0 = "https://docs.microsoft.com/en-us/learn/data-ai-cert/identify-faces-with-computer-vision/media/clo19_ubisoft_azure_068.png";
            var url1 = "https://d2skuhm0vrry40.cloudfront.net/2020/articles/2020-11-11-10-39/heres-our-first-look-at-sweaty-next-gen-fifa-21-player-faces-1605091143981.jpg/EG11/resize/1200x-1/heres-our-first-look-at-sweaty-next-gen-fifa-21-player-faces-1605091143981.jpg";
            var url2 = "https://image.shutterstock.com/image-photo/portrait-sad-man-260nw-126009806.jpg";
            var url3 = "https://www.cbc.ca/natureofthings/content/legacy/Universal_Expression_Surprise.jpg";
            var url4 = "https://i.pinimg.com/originals/48/1d/3b/481d3b523ed0b5c21a44b6a20806df06.jpg";

            var attributes = new FaceAttributeType[] {
                FaceAttributeType.Emotion,
                FaceAttributeType.Glasses,
                FaceAttributeType.Smile
            };
            bool includeId = true;
            bool includeLandmarks = false;

            var result = await faceClient.Face.DetectWithUrlAsync(url0, includeId, includeLandmarks, attributes);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

        }
        
       
        
    }
}
