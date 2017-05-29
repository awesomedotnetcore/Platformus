﻿// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using Platformus.Barebone;
using Platformus.Menus.Data.Models;

namespace Platformus.Menus
{
  public class MenuDeletedEventHandler : IMenuDeletedEventHandler
  {
    public int Priority => 1000;

    public void HandleEvent(IRequestHandler requestHandler, Menu menu)
    {
      requestHandler.HttpContext.RequestServices.GetService<ICache>().RemoveMenuViewComponentResult(menu.Code);
    }
  }
}