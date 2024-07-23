# adlerbot1

Welcome to the Adlerbot1 project, a node.js web application featuring a chatbot designed to provide an interactive user experience. This application includes a chatbot with an input area for users to type their messages and a response area that automatically scrolls to display all the interactions. The chatbot's functionality is now enhanced with the integration of Azure OpenAI, enabling it to provide dynamic responses to user queries. This server-side integration ensures efficient processing and response to user inputs through advanced AI models.

## Project Structure

- `chatbot-ui`: Contains the front-end code for the chatbot, including the input and response areas. The response area is designed to implement scrolling to ensure all messages are visible to the user.
- `server-api`: Houses the C# and .NET Core 8 server-side API code that services the chat requests from the front end. This directory includes all necessary configurations and controllers to handle chat interactions effectively, now including the capability to generate responses through Azure OpenAI.
- `azure-deployment`: This new folder contains the necessary bicep files for hosting the server-side implementation on an Azure Web App using a Basic 1 plan. It is designed to streamline the deployment process and ensure a robust hosting environment for the Adlerbot1 project.
- `chatbot-mobile-ui`: Contains the React Native project for the chatbot mobile UI app. This directory includes all necessary files and configurations to set up and run the mobile app.

## Azure OpenAI Services Deployment

Deploying Azure OpenAI services is crucial for enabling the advanced AI capabilities of Adlerbot1. Follow these steps to include Azure OpenAI services in your deployment:

1. Ensure you have an Azure account and are logged in to the Azure portal.
2. Navigate to the `azure-deployment` directory and update the `main.bicep` file to include the Azure Cognitive Services with the OpenAI API.
3. Deploy the updated Bicep template to Azure using the Azure CLI or through the Azure portal.
4. Verify the deployment of Azure OpenAI services in your Azure resource group.

For detailed instructions on deploying Azure OpenAI services, refer to the `azure-deployment/README.md`.

## Setting Up and Running the React Native Mobile UI App

Follow these instructions to set up and run the React Native mobile UI app:

### Prerequisites

Before you begin, ensure you have the following installed on your development machine:

- Node.js (https://nodejs.org/)
- npm (https://www.npmjs.com/)
- React Native CLI (https://reactnative.dev/docs/environment-setup)
- Android Studio (for Android development) or Xcode (for iOS development)

### Setup

1. Clone the repository and navigate to the `chatbot-mobile-ui` folder:

```bash
git clone <repository-url>
cd chatbot-mobile-ui
```

2. Install the project dependencies:

```bash
npm install
```

### Running the App

#### Android

1. Start the Android emulator or connect an Android device.
2. Run the following command to start the Metro bundler:

```bash
npm start
```

3. In a new terminal, run the following command to build and run the app on the Android device/emulator:

```bash
npm run android
```

#### iOS

1. Start the iOS simulator or connect an iOS device.
2. Run the following command to start the Metro bundler:

```bash
npm start
```

3. In a new terminal, run the following command to build and run the app on the iOS device/simulator:

```bash
npm run ios
```

### Testing

To run the tests for the React Native app, use the following command:

```bash
npm test
```

### Troubleshooting

If you encounter any issues during setup or running the app, refer to the official React Native documentation (https://reactnative.dev/docs/getting-started) for troubleshooting tips and solutions.

This project aims to provide a seamless and engaging chat experience, leveraging the latest technologies in web development and server-side processing.
