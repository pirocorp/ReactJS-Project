# ReactJS Project

Repository for ReactJS course project.

## Getting Started

The backend uses ASP.NET 5.0 and is in [src/server](https://github.com/pirocorp/ReactJS-Project/tree/main/src/server)

Start backend and wait for database initialization.

The frontend uses React and is in [src/client](https://github.com/pirocorp/ReactJS-Project/tree/main/src/client)

In client directory run 
```npm
  npm start
```

## Project Description

It is a Clinic / Hospital appointment booking system.

There will be three roles Admin, Doctor, and Patient.

Admin can create Doctors and can see all Patient and Doctors and all appointments registered in the system. (Not implemented yet)

A doctor can take shifts and accept or cancel patient appointments. Once accepted appointment can't cancel the appointment. (Implemented)

A patient can make an appointment with a given doctor. The patient sees all his appointments and their statuses. (Implemented)

Anonymous users can see all doctors in the clinic/hospital. Search for a doctor by name, specialization, or date. (Implemented)

### Class Component

SearchBar
