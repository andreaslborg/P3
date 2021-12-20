[![Contributors][contributors-shield]][contributors-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="http://taldigital.dk/">
    <img src="https://i.imgur.com/QtVY2Gm.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">AAU P3 Project | talDigital</h3>

  <p align="center">
    A Digital Information Board
    <br />
    <!--<a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a>
    <br />-->
    <br />
    <a href="https://edit.taldigital.dk/admin">View Admin Demo</a>
    ·
    <a href="https://taldigital.dk">talDigital.dk</a>
    ·
    <a href="#contact">Contact</a>
  </p>
</div>


<!-- ABOUT THE PROJECT -->
## About The Project

This project is made in cooperation with the startup company talDigital, which seeks to bring the advantages of digital solutions to information sharing into a very specific field: the information boards located around the entrances to parks and other green spaces. The idea is that the visitors of the green spaces can scan a QR code at the already existing information boards to access additional information about the concerning area on a digital information board. This could, for example, include news and upcoming events, descriptions of plants and animals, or history and practical information about the green space.

As of now the owner of talDigital has already contributed to the digital solution with a prototype. However, the prototype is currently hard-coded to only work with a few parks located around Aalborg. The prototype is developed using a drag and drop app builder, and therefore, it is not very suitable for a long-lasting solution. Instead the owner wishes a more dynamic solution with an administrative aspect that can be used to set up digital information boards in many areas. These boards are not necessarily only meant for parks, but also for other areas such as museums or at conferences.

The purpose of this project is to contribute with a system that supports the access of visitors to a digital information board. The system must also support the administration of the boards as well as allow the product owner to manage their licenses. The administration will be divided in two, namely administrators and editors. The administrators will be able to manage both the content of the information boards, as well as the editors, whereas the editors will only be able to manage the content.

### Built With

This project is build using ASP.NET, Blazor Server and Blazor Webassembly.

* [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
* [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)


<!-- GETTING STARTED -->
## Getting Started

To run the program, please follow these simple steps.

### Prerequisites

Before
* Install .NET 5.0 Runtime (<a href="https://download.visualstudio.microsoft.com/download/pr/bf3abcc3-5461-451c-9dd6-b74491cf0eed/84775adc7e46888289477b5c72e691fd/dotnet-hosting-5.0.12-win.exe" target="_blank">Win</a>)

### Run

1. Clone the repository
   ```
   gh repo clone andreasborgaau/P3
   ```
2. Choose which application you want to run
   ```
   cd /P3/ManagementPages
   ```
   or
   ```
   cd /P3/VisitorApplication/Server
   ```
3. Run the application
   ```
   dotnet watch run
   ```

<div id="contact">

<!-- CONTACT -->
## Contact

Software group mail - cs-21-sw-3-02@student.aau.dk
  <br />
Or contact Andreas Løvig Borg - alb19@student.aau.dk

Project Link: [github.com/andreasborgaau/P3](https://github.com/andreasborgaau/P3)
</div>

[contributors-shield]: https://img.shields.io/github/contributors/andreasborgaau/P3.svg?style=for-the-badge
[contributors-url]: https://github.com/andreasborgaau/P3/graphs/contributors
[stars-shield]: https://img.shields.io/github/stars/andreasborgaau/P3.svg?style=for-the-badge
[stars-url]: https://github.com/andreasborgaau/P3/stargazers
[issues-shield]: https://img.shields.io/github/issues/andreasborgaau/P3.svg?style=for-the-badge
[issues-url]: https://github.com/andreasborgaau/P3/issues
