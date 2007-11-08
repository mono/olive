// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//

using System;

namespace System.Windows.Input {

	public enum InputScopeNameValue {
		Xml = -4,
		Srgs = -3,
		RegularExpression = -2,
		PhraseList = -1,
		Default,
		Url,
		FullFilePath,
		FileName,
		EmailUserName,
		EmailSmtpAddress,
		LogOnName,
		PersonalFullName,
		PersonalNamePrefix,
		PersonalGivenName,
		PersonalMiddleName,
		PersonalSurname,
		PersonalNameSuffix,
		PostalAddress,
		PostalCode,
		AddressStreet,
		AddressStateOrProvince,
		AddressCity,
		AddressCountryName,
		AddressCountryShortName,
		CurrencyAmountAndSymbol,
		CurrencyAmount,
		Date,
		DateMonth,
		DateDay,
		DateYear,
		DateMonthName,
		DateDayName,
		Digits,
		Number,
		OneChar,
		Password,
		TelephoneNumber,
		TelephoneCountryCode,
		TelephoneAreaCode,
		TelephoneLocalNumber,
		Time,
		TimeHour,
		TimeMinorSec,
		NumberFullWidth,
		AlphanumericHalfWidth,
		AlphanumericFullWidth,
		CurrencyChinese,
		Bopomofo,
		Hiragana,
		KatakanaHalfWidth,
		KatakanaFullWidth,
		Hanja
	}
}
