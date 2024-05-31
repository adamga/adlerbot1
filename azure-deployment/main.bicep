// Bicep file to define Azure resources for hosting server-side implementation
resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: 'basic1Plan'
  location: resourceGroup().location
  sku: {
    name: 'B1'
    tier: 'Basic'
  }
  properties: {
    reserved: true // This is required for Linux plans
  }
}

resource webApp 'Microsoft.Web/sites@2020-06-01' = {
  name: 'adlerbot1WebApp'
  location: resourceGroup().location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings: [
        {
          name: 'WEBSITE_RUN_FROM_PACKAGE'
          value: '1'
        }
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: 'Production'
        }
      ]
      linuxFxVersion: 'DOTNETCORE|3.1' // Specify the .NET Core version
    }
    httpsOnly: true
  }
}
