import requests
import json

url = "http://localhost:5000/api/commands/"

payload = {"howTo":"Build .Net project","line": "dotnet build","platform":".NET Core CLI"}
headers = {}

response = requests.request("POST", url, json = payload, verify=False)

print(response.json())
print(response,response.headers,sep='\n')