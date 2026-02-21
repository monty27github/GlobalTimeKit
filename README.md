# GlobalTimeKit

**GlobalTimeKit** is a **.NET 9 class library** that provides **extension methods for DateTime and DateTimeOffset**, making it easy to handle **UTC, local time, time zones, parsing, formatting, Unix timestamps, ISO 8601, and human-readable differences**.  

It’s designed to save developers **setup time** by providing a robust, ready-to-use solution for handling dates and times consistently across applications.

---

## Features

- Convert between **Local ↔ UTC** easily
- Parse strings to **UTC or Local** with optional format and culture
- Handle **ISO 8601 formatted dates**
- Convert to/from **Unix timestamps**
- Work with **nullable DateTime/DateTimeOffset**
- Calculate **human-readable differences** with UTC or Local
- Handle **arrays or ranges** of dates
- Fully **culture-aware** and **DST-safe**
- Ready for **NuGet integration** in any .NET project

---

## Installation

Install via **NuGet**:

```bash
dotnet add package GlobalTimeKit
