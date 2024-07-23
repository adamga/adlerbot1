import React from 'react';
import { SafeAreaView, StyleSheet, TextInput, Button, View, ScrollView, Text } from 'react-native';

const App = () => {
  const [userInput, setUserInput] = React.useState('');
  const [messages, setMessages] = React.useState([]);

  const sendMessage = () => {
    if (userInput.trim() === '') return;

    setMessages([...messages, { type: 'user', text: userInput }]);
    setUserInput('');

    // Placeholder for sending the message to the server and receiving a response
    setTimeout(() => {
      setMessages((prevMessages) => [
        ...prevMessages,
        { type: 'bot', text: 'This is a placeholder response from the bot.' },
      ]);
    }, 1000);
  };

  return (
    <SafeAreaView style={styles.container}>
      <ScrollView style={styles.responseArea}>
        {messages.map((message, index) => (
          <View key={index} style={message.type === 'user' ? styles.userMessage : styles.botMessage}>
            <Text>{message.text}</Text>
          </View>
        ))}
      </ScrollView>
      <TextInput
        style={styles.input}
        value={userInput}
        onChangeText={setUserInput}
        placeholder="Type your message here..."
      />
      <Button title="Send" onPress={sendMessage} />
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'space-between',
    padding: 20,
  },
  responseArea: {
    flex: 1,
    marginBottom: 20,
  },
  input: {
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 10,
    paddingHorizontal: 10,
  },
  userMessage: {
    alignSelf: 'flex-end',
    backgroundColor: '#DCF8C6',
    borderRadius: 5,
    padding: 10,
    marginVertical: 5,
  },
  botMessage: {
    alignSelf: 'flex-start',
    backgroundColor: '#ECECEC',
    borderRadius: 5,
    padding: 10,
    marginVertical: 5,
  },
});

export default App;
