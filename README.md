# Global Right Management System

## Instructions

* To get help on how to run the program:

        GlobalRightManagement.exe -h
        -p, --DeliveryPartnerName    Required. Delivery Partner Name to be looked up.
        -d, --Date                   Required. Effective date, in mm/dd/yyyy format
        --help                       Display this help screen.
* Example: GlobalRightManagement.exe -p "ITunes" -d "12/5/2017"

## Assumptions

* Each distribution partner is only in contract for one and only one usage

## Design Notes

* The current design optimized for a distributed system architecture (Service oriented)
* It could be converted to DDD design if it is required
* Projects are configured to treat warnings as error
* Special annotation is used to keep all implementations internal. [assembly: InternalsVisibleTo("GlobalRightManagement.Test")]

## Compilation Notes

* Visual studio 2017, .NET Framework 4.6.1 and C# 6.0 compiler is required to build this code
* Access to internet is rewuired to download NuGet packages

## Testing

* Unit tests: Merely testing the component, mocking out underlying dependencies
* Integration tests:Testing the component with real dependencies
* Acceptance tests: Testing the system speciefications, making sure the expected behavior is in place
* All the tests are constructed with AAA(Arrange, Act, Assert) pattern