import requests
import json

url = "http://localhost:5000/api/commands/8"

payload = {"howTo":"Build .Net project","line": "dotnet build","platform":".NET Core CLI"}
headers = {}

response = requests.request("PUT", url, json = payload, verify=False)

print(f'{response.status_code}: {response.reason}',response.headers,sep='\n')