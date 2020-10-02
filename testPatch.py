import requests
import json

url = "http://localhost:5000/api/commands/8"

payload = [{"op":"replace","path": "platform","value":".Net Core command line"}]
headers = {}

response = requests.request("PATCH", url, json = payload, verify=False)

print(f'{response.status_code}: {response.reason}',response.headers,sep='\n')