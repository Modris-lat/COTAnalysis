import webScraper
import sendData

currencyData = webScraper.fetchData("https://www.cftc.gov/dea/futures/deacmesf.htm")
commodityData = webScraper.fetchData("https://www.cftc.gov/dea/futures/deacmxsf.htm")
usdData = webScraper.fetchData("https://www.cftc.gov/dea/futures/deanybtsf.htm")
energyData = webScraper.fetchData("https://www.cftc.gov/dea/futures/deanymesf.htm")

data = [currencyData, commodityData, usdData, energyData]
response = sendData.send("", data)

print(response)