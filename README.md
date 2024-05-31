# adlerbot1

Welcome to the Adlerbot1 project, a node.js web application featuring a chatbot designed to provide an interactive user experience. This application includes a chatbot with an input area for users to type their messages and a response area that automatically scrolls to display all the interactions. The chatbot's functionality is now enhanced with the integration of Azure OpenAI, enabling it to provide dynamic responses to user queries. This server-side integration ensures efficient processing and response to user inputs through advanced AI models.

## Project Structure

- `chatbot-ui`: Contains the front-end code for the chatbot, including the input and response areas. The response area is designed to implement scrolling to ensure all messages are visible to the user.
- `server-api`: Houses the C# and .NET Core 8 server-side API code that services the chat requests from the front end. This directory includes all necessary configurations and controllers to handle chat interactions effectively, now including the capability to generate responses through Azure OpenAI.
- `azure-deployment`: This new folder contains the necessary bicep files for hosting the server-side implementation on an Azure Web App using a Basic 1 plan. It is designed to streamline the deployment process and ensure a robust hosting environment for the Adlerbot1 project.

This project aims to provide a seamless and engaging chat experience, leveraging the latest technologies in web development and server-side processing.
