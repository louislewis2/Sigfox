# Sigfox

This .Net library facilitates working with the Sigfox backend api.
It is currently under development, thus not all endpoints are implemented.

# Helping Out

If you can assist in testing the library, that would help a lot.
I cannot test all endpoints with the account and devices I have.

# Packages

## Nuget Feed

[ Sigfox Nuget Link](https://www.nuget.org/packages/Sigfox/)

> Install-Package Sigfox

The latest version is 1.0.1

# Implemented Endpoints

## Users

* GET Users

## Devices

* GET Device
* PUT Device
* POST Device
* DELETE Device
* GET Devices
* GET Device Messages
* GET Device Messages Metric

## Contracts

* GET Contract
* GET Contracts
* Get Contract Devices


## Device Types

* GET Device Types
* GET Device Type Callbacks
* POST Device Type Callback
* PUT Device Type Callback
* DELETE Device Type Calback

## Api Users

* GET Api User
* GET Api Users
* POST Api User
* PUT Api User
* PUT Api User Profiles
* PUT Api User Credentials
* DELETE Api User Profile
* DELETE Api User

## Groups

* GET Group
* GET Groups
* GET Group Undelivered Callbacks
* GET Group GeoLocation Payloads
* POST Group
* PUT Group
* DELETE Group

## Profiles

* Get Profiles

# Running Tests

* Add Your Api Credentials In The Test Base Class.
Remember to clear them before you commit
