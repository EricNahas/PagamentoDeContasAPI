const amqp = require("amqplib");

const RABBIT_URL = "amqp://localhost";
const QUEUE = "account_created";

async function publishAccountCreated(account) {
    const connection = await amqp.connect(RABBIT_URL);
    const channel = await connection.createChannel();

    await channel.assertQueue(QUEUE, { durable: true });

    channel.sendToQueue(
        QUEUE,
        Buffer.from(JSON.stringify(account)),
        { persistent: true }
    );

    await channel.close();
    await connection.close();
}

module.exports = {
    publishAccountCreated
};
