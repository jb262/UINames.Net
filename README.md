# UINames.Net
Random name generator for the .NET-framework using the public and free API from uinames.com.
This very small and basic library was written in vb.NET, mainly for studying reasons.
## Usage
### Classes and Enums
The model consists of the following classes and enums defining its base model:
#### 1. Name (Class)
The basic name representation taken from uinames.com.
##### 1.1 Members
##### 1.1.1 Name: String
A persons's first name.
##### 1.1.2 Surname: String
A persons's last name.
##### 1.1.3 Gender: String
A person's gender.
##### 1.1.4 Region: String
The region name a person is coming from.
#### 2. Gender (Enum)
uinames.com does not provide other genders than female or male. Other genders will be represented as not specified in this library. This is not to be meant to be disrespectful to anyone identifying as any other gender than the conventional binary representation.
##### 2.1 Values
* NotSpecified
* Female
* Male
### Methods
This small library only exposes two methods to the public:
#### 1. GetName(gender: Gender (optional, default: Gender.NotSpecified), region (optional, default: null): System.Globalization.RegionInfo, minLength (optional, nullable, default: null): Integer, maxLength (optional, nullable, default: null)): Name
This method returns a single name from the API.

If a gender is specified, the name will be one of a person of the given gender, otherwise it will be random.

If the region is specified, the name will be one of a person coming from the given region, otherwise it will be random.

If the minLength is specified, the person's name will be at least as long as the given number, otherwise its minumum length will be zero.

If the maxLength is spcified, the person's name will be at most as long as the given number, otherwise its maximum legth will be unbounded.
#### 2. GetNames(amount: Integer, gender: Gender (optional, default: Gender.NotSpecified), region (optional, default: null): System.Globalization.RegionInfo, minLength (optional, nullable, default: null): Integer, maxLength (optional, nullable, default: null)): IEnumerable<Name>
This method returns an enumerable of a given length of names from the API.
  
The amount parameter specifies the number of names to be created.

If a gender is specified, the names will be ones of persons of the given gender, otherwise they will be random.

If the region is specified, the names will be one of persons coming from the given region, otherwise they will be random.

If the minLength is specified, the persons' names will be at least as long as the given number, otherwise their minumum length will be zero.

If the maxLength is spcified, the persons' names will be at most as long as the given number, otherwise their maximum legth will be unbounded.
#### Remarks
Non-Latin names, such as Greek, Chinese, etc. names, might be displayed as some funny characters.
