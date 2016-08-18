# Handlers
C# custom Handlers

## Usage
Simply add the desired files to your project, rename `MyApp.Models` to your namespace of choice and call the Methods as any other extension method:

```C#
new DateTime().ToUtcDate("Pacific Standard Time");

DateTime.Now.ToIsoString();

DateTime.UtcNow.ToLocalDateString("Central Standard Time");

"07/08/2016 06:12:24".ToSqlDate("");

"".ToLiteral();
```

You may also call them explicitly like `DateTimeHandler.ToUtcDate(DateTime, string)`.

When converting to UTC, the `string dateTimeZoneInfoId` will be used to define `DateTime this dateTime`'s Time Zone.
When converting to local, the `string dateTimeZoneInfoId` will be used to define the `return DateTime`'s Time Zone.

## Methods
DateTimeHandler:

```C#
string ToSqlDate(this DateTime dateTime, string timeZoneInfoId)
string ToSqlDate(this DateTime? dateTime, string timeZoneInfoId)
string ToSqlDate(this string dateTime, string timeZoneInfoId)

string ToIsoString(this DateTime dateTime, string timeZoneInfoId)
string ToIsoString(this DateTime? dateTime, string timeZoneInfoId)

string ToLocalDateString(this string dateTime, string timeZoneInfoId)
string ToLocalDateString(this DateTime dateTime, string timeZoneInfoId)
string ToLocalDateString(this DateTime? dateTime, string timeZoneInfoId)

DateTime ToUtcDate(this DateTime dateTime, string timeZoneInfoId)
```

HtmlStringHandler:

```C#
IHtmlString ToLiteral(this string text)
IHtmlString ToLiteral(this IHtmlString text)
```
