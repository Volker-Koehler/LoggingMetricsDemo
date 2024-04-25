# Logging Metrics Demo

This repository contains a demo for setting up Elasticsearch, Kibana, and a .NET web application using Docker.

## Prerequisites

Before you begin, make sure you have the following installed on your machine:

- Docker: [Install Docker](https://docs.docker.com/get-docker/)

## Getting Started

Follow the steps below to set up the demo:

1. Clone this repository:

    ```bash
    git clone https://github.com/Volker-Koehler/LoggingMetricsDemo.git
    ```

2. Navigate to the project directory:

    ```bash
    cd LoggingMetricsDemo
    ```

3. Start Elasticsearch and Kibana containers:

    ```bash
    docker-compose up -d --build
    ```

    This will start Elasticsearch and Kibana containers in the background.

4. Build and run the .NET web application:

    ```bash
    dotnet build 
    dotnet run
    ```

    This will build and run the .NET web application container.

5. Access the web application:

    Open your web browser and navigate to [http://localhost:5000](http://localhost:5000) to access the web application.

## Cleanup

To stop and remove the containers, run the following command:
