# This program sends an HTTP request to Azure's Bing Search API with given query.
# Author: Tuna Cinsoy
# Last Modification: 27.02.21

import json
import os
from pprint import pprint
import requests

subscription_key = os.environ["BING_SEARCH_KEY"]
endpoint = os.environ["BING_SEARCH_ENDPOINT"]

query = "Dogs"

mkt = 'en-US'
responseFilter = 'News'

params = { 'q': query, 'mkt': mkt, 'responseFilter': responseFilter}
headers = { 'Ocp-Apim-Subscription-Key': subscription_key }

# Call the API
try:
    response = requests.get(endpoint, headers=headers, params=params)
    response.raise_for_status()

    print("\nJSON Response:\n")
    pprint(response.json())
except Exception as ex:
    raise ex