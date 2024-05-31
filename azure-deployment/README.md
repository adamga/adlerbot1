# Azure Deployment for Adlerbot1

This folder contains the Bicep files necessary for deploying the server-side implementation of Adlerbot1 to an Azure Web App using a Basic 1 plan. The main purpose of these files is to streamline the deployment process and ensure a robust hosting environment for the application.

## Deployment Instructions

To deploy the Adlerbot1 server-side implementation using these Bicep files, follow these steps:

1. Ensure you have the Azure CLI installed and logged in to your Azure account.
2. Navigate to the `azure-deployment` directory in your terminal.
3. Run the following command to deploy the Bicep template to Azure:

```bash
az deployment group create --resource-group <YourResourceGroupName> --template-file main.bicep
```

Replace `<YourResourceGroupName>` with the name of your Azure resource group.

For more detailed instructions and troubleshooting, refer to the official Azure Bicep documentation.

## Deploying Azure OpenAI Services

To include Azure OpenAI services in your deployment, follow these additional steps:

1. Ensure the `main.bicep` file includes the Azure Cognitive Services with the OpenAI API as described in the updated `main.bicep` documentation.
2. Deploy or update your Azure resources using the Azure CLI with the updated `main.bicep` file to include Azure OpenAI services.
3. Verify the deployment of Azure OpenAI services in your Azure resource group to ensure they are correctly configured for use with Adlerbot1.
