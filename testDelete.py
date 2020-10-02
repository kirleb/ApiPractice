import requests

url = "http://localhost:5000/api/commands/16"

payload = {}
headers = {}

response = requests.request("DELETE", url, verify=False)

print(f'{response.status_code}: {response.reason}',response.headers,sep='\n')