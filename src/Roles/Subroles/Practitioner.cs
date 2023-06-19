using Lotus.API.Odyssey;
using Lotus.GUI.Name;
using Lotus.GUI.Name.Components;
using Lotus.GUI.Name.Holders;
using Lotus.Managers.History.Events;
using Lotus.Roles.Internals.Attributes;
using Lotus.Roles.Subroles;
using UnityEngine;
using VentLib.Localization.Attributes;
using VentLib.Utilities;


namespace Lotus.Roles.RoleGroups.Crew;

[Localized("Roles.Subroles.Practitioner")]

public class Practitioner : Subrole
{
    public override string Identifier() => "♬";

    [RoleAction(RoleActionType.AnyDeath)]
    private void PractitionerAnyDeath(PlayerControl dead, IDeathEvent causeOfDeath)
    {
        string coloredString = "<size=1.6>" + Color.white.Colorize($"({RoleColor.Colorize(causeOfDeath.SimpleName())})") + "</size>";

        TextComponent textComponent = new(new LiveString(coloredString), GameState.InMeeting, viewers: MyPlayer);
        dead.NameModel().GetComponentHolder<TextHolder>().Add(textComponent);
    }


    [Localized(nameof(PractitionerDescription))]
    public static string PractitionerDescription = "The Practitioner lets you see how people died.";
    protected override RoleModifier Modify(RoleModifier roleModifier)
    {
        return base.Modify(roleModifier).RoleColor(new Color(0.32f, 0.74f, 1f));
    }
}