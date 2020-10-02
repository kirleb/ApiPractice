import requests

url = "https://localhost:5001/api/commands/3"

payload = {}
headers= {}

response = requests.request("GET", url, headers=headers, data = payload, verify=False)

print(response.json())
