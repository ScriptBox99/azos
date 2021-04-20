﻿/*<FILE_LICENSE>
 * Azos (A to Z Application Operating System) Framework
 * The A to Z Foundation (a.k.a. Azist) licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
</FILE_LICENSE>*/

using System;

namespace Azos.Data.Heap
{
  /// <summary>
  /// Assigns (AREA, COLLECTION) tuple to HeapObjects. The attribute must be set to bind
  /// a CLI type to collection within data heap area.
  /// You can only bind no more than one CLR object type to a named collection at a time.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public sealed class HeapAttribute : Attribute
  {
    public HeapAttribute(string area, string space)
    {
      Area = area.CheckId(nameof(area));
      Space = space.CheckId(nameof(space));
    }

    //todo:  constrain identifiers to character only or 0..9, -, _, min length 3, max length 32
    public string Area{ get; private set;}
    public string Space{ get; private set; }

    //public Atom Channel { get; private set; }

    //public string ChannelName
    //{
    //  get => Channel.Value;
    //  set => Channel = Atom.Encode(value.NonBlank(nameof(ChannelName)));
    //}

  }
}
