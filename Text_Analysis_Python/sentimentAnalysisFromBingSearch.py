# This program aims to test Text Analytics service of Microsoft Azure's Cognitive Services, based on sentiment analysis. 
# Data: Bing Search API
# Author: Tuna Cinsoy
# Last Modification: 27.02.21

from pip._vendor import requests
from pprint import pprint

import os

# variables to store subscription key and root URL for the Cognitive Service resource
subscription_key = os.environ["TEXT_ANALYTICS_KEY"]
endpoint = os.environ["TEXT_ANALYTICS_ENDPOINT"]

# append the Text Analytics endpoint information to the URL
entities_url = endpoint + "/text/analytics/v2.0/sentiment"

# variable to store a JSON formatted document that contains two entries in a JSON array.
documents = {"documents": [
    {"id": "1", "text": "Lady Gaga's stolen dogs were turned in unharmed Friday night, the Los Angeles Police Department said. "},
    {"id": "2", "text": "A woman brought the dogs into the LAPD's Olympic station in Koreatown on Friday night, police confirmed."},
    {"id": "3", "text": "On Wednesday night, two of Lady Gaga's French Bulldogs were stolen by armed thieves who shot her dog walker and friend, Ryan Fischer. "},
    {"id": "4", "text": "Gaga's dogs Koji and Gustav were turned in safe at the LAPD Olympic station around 6 P."},
    {"id": "5", "text": "Lady Gaga's two French bulldogs, which were stolen by thieves who shot and wounded their walker, were recovered unharmed Friday, Los Angeles police said."},
    {"id": "6", "text": "Twitter/Lady GagaLady Gaga’s two French bulldogs, stolen off the streets of Los Angeles Wednesday night, are homeward bound after being safely returned, according to NBC."},
    {"id": "7", "text": "An unidentified woman reportedly turned the animals in to the Los Angeles Police Department’s Olympic Community Police Station around 6 p."},
    {"id": "8", "text": "Lady Gaga’s two French bulldogs, which were stolen by thieves who shot and wounded the dog walker, were recovered unharmed Friday, Los Angeles police said."}
]}

# Setup the header information for the REST request passing in the subscription key
headers = {"Ocp-Apim-Subscription-Key": subscription_key}

# Build the REST request by passing in the complete URL, header information for authentication, and the JSON document
response = requests.post(entities_url, headers=headers, json=documents)

# Create a variable to store the results that are returned from the REST request
entities = response.json()

# Output the result using pprint.
pprint(entities)