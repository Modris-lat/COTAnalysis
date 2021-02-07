import urllib.request, urllib.parse, urllib.error
import json
import ssl

async def fetchData(url):
    uh = await urllib.request.urlopen(url)
    data = uh.read().decode()
    return data