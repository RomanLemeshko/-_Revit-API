using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
public class InsulationDucts
{
    public ParametersDto Set(ParametersDto parametersDto)
    {
        List<Element> ductInsulation = new FilteredElementCollector(parametersDto.doc).OfClass(typeof(DuctInsulation)).ToList();
        foreach (Element elem in ductInsulation)
        {
            elem.get_Parameter(parametersDto.guidParamName).Set
            (parametersDto.doc.GetElement(elem.GetTypeId()).get_Parameter(parametersDto.guidParamNamePipeAndDuct).AsString() + ", толщина изоляции " +
            elem.get_Parameter(BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_DUCT).AsValueString());

            elem.get_Parameter(parametersDto.guidParamCount).Set((elem.get_Parameter(parametersDto.guidParamSizeArea).AsDouble()) / 10.7639104167097);
        }
        return parametersDto;
    }
}


