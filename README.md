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

When converting to UTC, the `string dateTimeZoneInfoId` will be used to define `DateTime dateTime`'s Time Zone.<br>
When converting to local, the `string dateTimeZoneInfoId` will be used to define the `return DateTime`'s Time Zone.

If `timeZoneInfoId` is null or empty, `DateTime dateTime` will be converted normally with `.ToUniversalTime()`.

Invalid `timeZoneInfoId`s like `"en-US"` will throw an Exception.

## Methods
**DateTimeHandler:**

```C#
string ToSqlDate(this DateTime dateTime, string timeZoneInfoId = null)
string ToSqlDate(this DateTime? dateTime, string timeZoneInfoId = null)
string ToSqlDate(this string dateTime, string timeZoneInfoId = null)

string ToIsoString(this DateTime dateTime, string timeZoneInfoId = null)
string ToIsoString(this DateTime? dateTime, string timeZoneInfoId = null)

string ToLocalDateString(this string dateTime, string timeZoneInfoId = null)
string ToLocalDateString(this DateTime dateTime, string timeZoneInfoId = null)
string ToLocalDateString(this DateTime? dateTime, string timeZoneInfoId = null)

DateTime ToUtcDate(this DateTime dateTime, string timeZoneInfoId = null)
```

**HtmlStringHandler:**

```C#
IHtmlString ToLiteral(this string text)
IHtmlString ToLiteral(this IHtmlString text)
```
