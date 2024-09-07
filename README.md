## Features
- Zoom OAuth authentication

## Configuration

Before running the application, you'll need to configure your `appsettings.json` file to include your `ClientID`, `ClientSecret`, and `account_id` values.

### Setting Up appsettings.json

1. Navigate to the `appsettings.json` file in the root of your project.
2. Replace the placeholder values for `ClientID`, `ClientSecret`, and `account_id` with your actual credentials.

Here's an example configuration:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Api-keys": {
    "ClientID": "your-client-id",
    "ClientSecret": "your-client-secret",
    "account_id": "your-account-id"
  }
}
