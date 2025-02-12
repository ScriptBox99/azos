﻿/*<FILE_LICENSE>
 * Azos (A to Z Application Operating System) Framework
 * The A to Z Foundation (a.k.a. Azist) licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
</FILE_LICENSE>*/

using System;

using Azos.Data;
using Azos.Time;
using Azos.Scripting;
using Azos.Serialization.JSON;
using System.Linq;
using static Azos.Aver;

namespace Azos.Tests.Nub.Time
{
  [Runnable]
  public class HourListTestsJpk
  {

    [Run]
    public void Single_ZeroHourOnly()
    {
      var got = new HourList("0-1");
      var span = got.Spans.First();
      Aver.AreEqual(1, got.Spans.Count());
      Aver.AreEqual(0, got.Spans.First().StartMinute);
      Aver.AreEqual(60, got.Spans.First().DurationMinutes);
      "{0} {1}".SeeArgs(span.Start, span.Finish);
    }

    [Run]
    public void Single_23ToZeroHourOnly()
    {
      var got = new HourList("23-24");
      var span = got.Spans.First();
      got.Spans.Count().See();
      "{0} {1}".SeeArgs(span.Start, span.Finish);

      Aver.AreEqual(1, got.Spans.Count());
      Aver.AreEqual(1380, got.Spans.First().StartMinute);
      Aver.AreEqual(60, got.Spans.First().DurationMinutes);
    }

    [Run]
    public void Day_ZeroTo24Hour()
    {
      var got = new HourList("0-24");
      var span = got.Spans.First();
      got.Spans.Count().See();
      "{0} {1}".SeeArgs(span.Start, span.Finish);

      Aver.AreEqual(1, got.Spans.Count());
      Aver.AreEqual(0, got.Spans.First().StartMinute);
      Aver.AreEqual(1440, got.Spans.First().DurationMinutes);
    }

    [Run]
    [Throws(ExceptionType = typeof(TimeException))]
    public void Day_Zero1MinTo24Hour1Min()
    {
      var got = new HourList("0:01-24:01");
      var span = got.Spans.First();
      got.Spans.Count().See();
    }

    [Run]
    public void Day_ZeroTo23Hour()
    {
      var got = new HourList("0-23");
      var span = got.Spans.First();
      got.Spans.Count().See();
      "{0} {1}".SeeArgs(span.Start, span.Finish);

      Aver.AreEqual(1, got.Spans.Count());
      Aver.AreEqual(0, got.Spans.First().StartMinute);
      Aver.AreEqual(1380, got.Spans.First().DurationMinutes);
    }

    [Run]
    [Throws(ExceptionType =typeof(TimeException))]
    public void Throw_OnOverlap()
    {
      var got = new HourList("22:66-23");
      Aver.AreEqual(1, got.Spans.Count());
    }

  }
}
