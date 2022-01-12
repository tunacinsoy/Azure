# This program aims to test Text Analytics service of Microsoft Azure's Cognitive Services, based on sentiment analysis.
# Data: Sample Use Cases From Internet
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
    {"id": "1", "text": "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC interpreters for the Altair 8800."},
    {"id": "2", "text": "I really like the new design of your website!"},
    {"id": "3", "text": "I love you."},
    {"id": "4", "text": "I’m not sure if I like the new design"},
    {"id": "5", "text": "The new design is awful!"},
    {"id": "6", "text": "High quality pants. Very comfortable and great for sport activities. Good price for nice quality! I recommend to all fans of sports"},
    {"id": "7", "text": "The older interface was much simpler"},
    {"id": "8", "text": "Your customer service is a nightmare! Totally useless!!"},
    {"id": "9", "text": "Very frustrated right now. Instagram keeps closing when I log in. Can you help?"},
    {"id": "10", "text": "I love how Zapier takes different apps and ties them together"}
]}

# Setup the header information for the REST request passing in the subscription key
headers = {"Ocp-Apim-Subscription-Key": subscription_key}

# Build the REST request by passing in the complete URL, header information for authentication, and the JSON document
response = requests.post(entities_url, headers=headers, json=documents)

# Create a variable to store the results that are returned from the REST request
entities = response.json()

# Output the result using pprint.
pprint(entities)