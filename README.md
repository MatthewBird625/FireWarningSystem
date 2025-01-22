# Fire Warning System
An Australia wide fire warning system, built to show my current coding capabilities. 

## Archetecture
Archetecture used is MVVM aretecture divided into three layers. See descriptions below and diagram. 

### Web Layer
The first layer is the ".Web" Layer. In this layer exists the razor components, their associated partial classes and supporting CSS files when CSS is required in a component. The razor component itself is used to place razor / mudblazor syntax, along with some simple C# conditionals to control what components are rendered. The Partial class file contains the injections of the ViewModel, simple class declarations such as forms/validators and some simple C# methods as needed. The most important element here is the Injection of the ViewModel, allowing access to the UI Logic Layer. 

### UILogic Layer
The UI Layer sees the introduction of more complex C#, as well as the complete removal of the usage of any razor syntax. This forms a clear distinction between the markup that drives our application, and the "display logic" that drives the user experience. The removal of razor / mudblazor usage in this layer also allows for concrete implementations of the ViewModel to be easily tested using unit testing, without having to deal with any view entanglement. This Layer also consists of Models and Validators where needed for forms and also services for rendering or changing elements on the page. Again the removal of these elements from the any entanglement in the Web layer allows for easy unit testing. 

### Data Layer - not required in this application
The Data Layer is for services and models primarily relating to Database or CRM access. It can also be used for access to Cloud Services, Security services etc. It can be thought of as the core backend of the archetecture. 


![arch diagram](https://github.com/MatthewBird625/FireWarningSystem/blob/main/diagram.png) 


## How to run - Coming Soon!!!!


