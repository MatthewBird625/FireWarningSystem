# Fire Warning System
An Australia wide fire warning system, built to show my current coding capabilities. 

This application collects emergency services warnings from each Australian State or territory and places relevant information from each Warning on an Azure map using the latitude and location collected via the APIs. 

There is also a basic contact form to show dynamic page changes without the need for URL changes, and to also demonstrate basic form validation. 

## Archetecture
Archetecture used is MVVM aretecture divided into three layers. See descriptions below and diagram. 

### Web Layer
The first layer is the ".Web" Layer. In this layer exists the razor components, their associated partial classes and supporting CSS files when CSS is required in a component. The razor component itself is used to place razor / mudblazor syntax, along with some simple C# conditionals to control what components are rendered. The Partial class file contains the injections of the ViewModel, simple class declarations such as forms/validators and some simple C# methods as needed. The most important element here is the Injection of the ViewModel, allowing access to the UI Logic Layer. 

### UILogic Layer
The UI Layer sees the introduction of more complex C#, as well as the complete removal of the usage of any razor syntax. This forms a clear distinction between the markup that drives our application, and the "display logic" that drives the user experience. The removal of razor / mudblazor usage in this layer also allows for concrete implementations of the ViewModel to be easily tested using unit testing, without having to deal with any view entanglement. This Layer also consists of Models and Validators where needed for forms and also services for rendering or changing elements on the page. Again the removal of these elements from the any entanglement in the Web layer allows for easy unit testing. 

### Data Layer
The Data Layer is for services and models primarily relating to Database or CRM access. It can also be used for access to Cloud Services, Security services etc. It usually does not have an effect on the components or C# Models / Logic that make up the front end. It can be thought of as the core backend of the archetecture. 

END CORE ARCH LAYERS
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
### WarningClient
The Client Responsible for collecting the fire warning systems API from various states. I prefer to move API clients to standalone modules for ease of re-use in other applications. But within the context of this App it could of also just been implemented within the Data Layer. 

![arch diagram](https://github.com/MatthewBird625/FireWarningSystem/blob/main/diagram.png) 

## Quick Demo Video:

https://youtu.be/I7dKhDEfMhE

## How to run

1. Clone this repo and open in visual studio.

2. An Azure maps key is required to run this App. 
 Create an Azure maps Api Key following this guide:
https://www.easyterritory.com/documentation/administrator/get-azure-maps-key/

3. Add the following to the FireWarningSystem.Web Secrets, updating the Key Value with your Azure Maps key: 

{
  "AzureMapsSubscriptionKey": "YOUR-KEY-HERE"
}

4. Set up a dummy SMTP testing service. You can use free tier Mail Trap, or SMTP4Dev, which is used in the Demonstration Video - see installation instructions in its repo (https://github.com/rnwood/smtp4dev)

5. Update   "SmtpServer": "YOUR-SMTP-SERVER-ADDRESS" in the appsettings.json with the address of your test SMTP server. 

6. Run the app! 

## Unit Testing

Some unit testing is included to demonstrate knowledge of Unit Testing and the Moq framework. 

These can be run by simply right clicking the solution in the solution explorer in visual studio and clicking "Run Tests"
