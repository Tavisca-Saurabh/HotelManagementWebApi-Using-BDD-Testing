Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

@GetHotelByID
Scenario Outline: User add hotel & verify that hotel in database by providing valid input
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls GetHotelById api by '<id>'
	Then Hotel with id '<id>' should be present in the response
Examples: 
| id | name   |
| 10  | hotel4 |
| 11  | hotel5 |
| 12  | hotel6 |

@Getlistofallthehotelsadded
Scenario: Get list of all the hotels added
	Given User provided valid Id '5'  and 'hotel5'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api	
	And User provided valid Id '6'  and 'hotel6'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls GetAllHotels
	Then Verify all added hotels are present