public static class FormationFactory
{
    public static IFormation Create(FormationType type)
    {
        return type switch
        {
            FormationType.Line => new LineFormation(columns: 2),
            FormationType.Wedge => new WedgeFormation(),
            FormationType.Box => new BoxFormation(),
            FormationType.Chaotic => new ChaoticFormation(),
            _ => new LineFormation(columns: 3),
        };
    }
}
