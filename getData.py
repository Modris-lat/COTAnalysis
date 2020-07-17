import urllib.request, urllib.parse, urllib.error
import json
import ssl

uh = urllib.request.urlopen('https://www.cftc.gov/dea/futures/deacmesf.htm')
currencyData = uh.read().decode()
uh = urllib.request.urlopen('https://www.cftc.gov/dea/futures/deacmxsf.htm')
commodityData = uh.read().decode()
uh = urllib.request.urlopen('https://www.cftc.gov/dea/futures/deanybtsf.htm')
usdData = uh.read().decode()
uh = urllib.request.urlopen('https://www.cftc.gov/dea/futures/deanymesf.htm')
energyData = uh.read().decode()

currencyOpen = open('currencyData.txt', 'w')
currencyOpen.write(currencyData)
currencyOpen.close()

commodityOpen = open('commodityData.txt', 'w')
commodityOpen.write(commodityData)
commodityOpen.close()

usdOpen = open('usdData.txt', 'w')
usdOpen.write(usdData)
usdOpen.close()

energyOpen = open('energyData.txt', 'w')
energyOpen.write(energyData)
energyOpen.close()



