﻿// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using Platformus.Barebone;
using Platformus.Domain.Data.Models;

namespace Platformus.Domain
{
  public class ObjectDeletedEventHandler : IObjectDeletedEventHandler
  {
    public int Priority => 1000;

    public void HandleEvent(IRequestHandler requestHandler, Object @object)
    {
      string urlPropertyStringValue = string.Format("/{0}", new ObjectManager(requestHandler).GetUrlPropertyStringValue(@object));

      requestHandler.HttpContext.RequestServices.GetService<ICache>().RemovePageActionResult(urlPropertyStringValue);
    }
  }
}