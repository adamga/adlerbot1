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
        {
          name: 'ChatDatabaseConnectionString'
          value: sqlDatabase.properties.connectionString
        }
      ]
      linuxFxVersion: 'DOTNETCORE|3.1' // Specify the .NET Core version
    }
    httpsOnly: true
  }
}

// Adding Azure Cognitive Services with OpenAI API
resource cognitiveServices 'Microsoft.CognitiveServices/accounts@2021-04-30' = {
  name: 'adlerbot1OpenAIService'
  location: resourceGroup().location
  kind: 'OpenAI'
  sku: {
    name: 'S0'
  }
  properties: {
    customSubDomainName: 'adlerbot1-openai'
    networkAcls: {
      defaultAction: 'Allow'
    }
  }
}

// Adding SQL Server resource
resource sqlServer 'Microsoft.Sql/servers@2021-02-01-preview' = {
  name: 'adlerbot1SqlServer'
  location: resourceGroup().location
  properties: {
    administratorLogin: 'sqladmin'
    administratorLoginPassword: 'P@ssw0rd!'
  }
  sku: {
    name: 'Standard'
    tier: 'GeneralPurpose'
  }
}

// Adding SQL Database resource
resource sqlDatabase 'Microsoft.Sql/servers/databases@2021-02-01-preview' = {
  name: 'adlerbot1Database'
  location: resourceGroup().location
  properties: {
    serverName: sqlServer.name
  }
  sku: {
    name: 'S0'
  }
}
