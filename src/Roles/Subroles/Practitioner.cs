using Lotus.API.Odyssey;
using Lotus.GUI.Name;
using Lotus.GUI.Name.Components;
using Lotus.GUI.Name.Holders;
using Lotus.Managers.History.Events;
using Lotus.Roles.Internals.Attributes;
using Lotus.Roles.RoleGroups.Vanilla;
using Lotus.Roles.Subroles;
using UnityEngine;
using VentLib.Localization.Attributes;
using VentLib.Options.Game;
using VentLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Lotus.Factions;
using Lotus.Factions.Interfaces;
using Lotus.Extensions;
using Lotus.Roles.Extra;
using Lotus.Roles.Interfaces;

namespace Lotus.Roles.RoleGroups.Crew;

[Localized("Roles.Subroles.Practitioner")]

public class Practitioner : Crewmate
{
    [RoleAction(RoleActionType.AnyDeath)]
    private void PractitionerAnyDeath(PlayerControl dead, IDeathEvent causeOfDeath)
    {
        string coloredString = "<size=1.6>" + Color.white.Colorize($"({RoleColor.Colorize(causeOfDeath.SimpleName())})") + "</size>";

        TextComponent textComponent = new(new LiveString(coloredString), GameState.InMeeting, viewers: MyPlayer);
        dead.NameModel().GetComponentHolder<TextHolder>().Add(textComponent);
    }


    [Localized(nameof(PractitionerDescription))]
    public static string PractitionerDescription = "The Practitioner lets you see how people died.";
    protected override RoleModifier Modify(RoleModifier roleModifier) =>
        base.Modify(roleModifier).RoleColor(new Color(0.32f, 0.74f, 1f));
    public static class Options { }

}