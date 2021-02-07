import requests

async def send(url, send):
    message = {"message": send}
    response = await requests.post(url, data = message)
    return response