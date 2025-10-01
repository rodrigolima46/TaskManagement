TaskWeb – Simple Task Manager

A lightweight ASP.NET Core web app built with EF Core and SQLite.
=======================================================================================================================================
## 🐳 Running with Docker

This project is available as a Docker image on Docker Hub.
[Docker image](https://hub.docker.com/r/rodrigolimao46/taskweb)


### Pull the image

docker pull rodrigolimao46/taskweb:latest

=======================================================================================================================================

This project uses **SendGrid** for sending emails (e.g., account registration, password reset). To enable email sending:

1. **Create a SendGrid Account**  
   - Go to [SendGrid](https://sendgrid.com/) and sign up.
   - Generate an **API Key** with `Full Access`.

2. **Verify a Sender Email**  
   - Add and verify the email address you want to use as the sender (`FromEmail`).

3. **Run the Project with Environment Variables**  
   When running the app with Docker, provide the SendGrid info:

   docker run -d -p 5000:8080 --name taskweb \
       -e SendGrid__ApiKey="YOUR_SENDGRID_API_KEY" \
       -e SendGrid__FromEmail="your_email@example.com" \
       -e SendGrid__FromName="Your Name" \
       taskweb:latest

