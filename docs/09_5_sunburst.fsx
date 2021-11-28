(**
---
title: Sunburst Charts
category: Categorical Charts
categoryindex: 10
index: 6
---
*)


(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Sunburst charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create sunburst charts in F#.

Sunburst Chart � also known as Ring Chart, Multi-level Pie Chart, and Radial Treemap � is typically used to visualize hierarchical data structures.
A Sunburst Chart consists of an inner circle surrounded by rings of deeper hierarchy levels.
The angle of each segment is either proportional to a value or divided equally under its parent node.

## Simple sunburst plot
*)
open Plotly.NET 

let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]

let sunburstChart =
    Chart.Sunburst(
        ["A";"B";"C";"D";"E"],
        ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        MultiText=["At";"Bt";"Ct";"Dt";"Et"]
    )

(**
## More styled example

This example shows the usage of some of the styling possibility using `Chart.Sunburst`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.Sunburst`
*)

let sunburstStyled = 
    let labelsParents = [
        ("A",""), 20
        ("B",""), 1
        ("C",""), 2
        ("D",""), 3
        ("E",""), 4

        ("AA","A"), 15
        ("AB","A"), 5

        ("BA","B"), 1

        ("AAA", "AA"), 10
        ("AAB", "AA"), 5
    ]

    Chart.Sunburst(
        labelsParents |> Seq.map fst,
        Values = (labelsParents |> Seq.map snd), 
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Rotation = 45,
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
sunburstStyled
#endif // IPYNB
    
(***hide***)
sunburstStyled |> GenericChart.toChartHTML
(***include-it-raw***)