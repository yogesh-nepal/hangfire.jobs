# hangfire.jobs

hangfire.jobs is an ASP.NET 8 application demonstrating the integration of Hangfire for background job processing. This repository provides examples of different types of background jobs, including fire-and-forget, delayed, recurring, and continuation jobs.

## Description

Hangfire is a .NET library that simplifies the execution of background tasks in web applications. This demo project illustrates how Hangfire can be utilized to handle various background job scenarios efficiently.

## Features

- **Fire-and-Forget Jobs:** Execute tasks immediately and once.
- **Delayed Jobs:** Execute tasks after a specified delay.
- **Recurring Jobs:** Execute tasks at regular intervals.
- **Continuation Jobs:** Execute tasks sequentially after preceding tasks complete.

## Getting Started

To run the hangfire.jobs project locally:

1. Clone the repository.
2. Install the .NET 8 SDK and Hangfire NuGet packages.
3. Restore dependencies and build the project.
4. Run the application.
5. Access the Hangfire Dashboard to monitor background job processing.

## Hangfire Dashboard

The Hangfire Dashboard provides a user-friendly interface for monitoring background job execution. It offers insights into job status, execution times, and failure information.

## Project Structure

- **Controllers:** Contains endpoints to trigger different types of background jobs.
- **Jobs:** Defines classes for implementing various background job types.

## Acknowledgments

- Hangfire documentation for providing comprehensive guidance on integrating and utilizing the library.
