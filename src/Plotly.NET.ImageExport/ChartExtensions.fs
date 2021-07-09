﻿namespace Plotly.NET.ImageExport

open System
open System.IO

open Plotly.NET
open GenericChart
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

/// Extensions methods from Plotly.NET.ImageExport for the Chart module, supporting the fluent pipeline style
[<AutoOpen>]
module ChartExtensions =
    
    type internal RenderOptions
        (
            ?EngineType: ExportEngine,
            ?Width : int,
            ?Height : int
        ) =
            member _.Engine = (defaultArg EngineType ExportEngine.PuppeteerSharp) |> ExportEngine.getEngine
            member _.Width = defaultArg Width 600
            member _.Height = defaultArg Height 600

    type Chart with
        
        [<CompiledName("ToBase64JPGStringAsync")>]
        static member toBase64JPGStringAsync
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 

                let opts = RenderOptions(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
                fun (gChart:GenericChart) -> opts.Engine.RenderJPGAsync(opts.Width, opts.Height, gChart)
               
        [<CompiledName("ToBase64JPGString")>]
        static member toBase64JPGString
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                fun (gChart:GenericChart) ->
                    gChart
                    |> Chart.toBase64JPGStringAsync(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                    |> Async.RunSynchronously

        [<CompiledName("SaveJPGAsync")>]
        static member saveJPGAsync 
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 

                let opts = RenderOptions(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
                fun (gChart:GenericChart) -> opts.Engine.SaveJPGAsync(path, opts.Width, opts.Height, gChart)

        [<CompiledName("SaveJPG")>]
        static member saveJPG
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                fun (gChart:GenericChart) ->
                    gChart
                    |> Chart.saveJPGAsync(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
                    |> Async.RunSynchronously


        [<CompiledName("ToBase64PNGStringAsync")>]
        static member toBase64PNGStringAsync
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
            
                let opts = RenderOptions(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
                fun (gChart:GenericChart) -> opts.Engine.RenderPNGAsync(opts.Width, opts.Height, gChart)

        [<CompiledName("ToBase64PNGString")>]
        static member toBase64PNGString
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                fun (gChart:GenericChart) ->
                    gChart
                    |> Chart.toBase64PNGStringAsync(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                    |> Async.RunSynchronously

        [<CompiledName("SavePNGAsync")>]
        static member savePNGAsync
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                let opts = RenderOptions(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
                fun (gChart:GenericChart) -> opts.Engine.SavePNGAsync(path, opts.Width, opts.Height, gChart)

        [<CompiledName("SavePNG")>]
        static member savePNG
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                fun (gChart:GenericChart) ->
                    gChart
                    |> Chart.savePNGAsync(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
                    |> Async.RunSynchronously
            
        [<CompiledName("ToSVGStringAsync")>]
        static member toSVGStringAsync
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                let opts = RenderOptions(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
                fun (gChart:GenericChart) -> opts.Engine.RenderSVGAsync(opts.Width, opts.Height, gChart)

        [<CompiledName("ToSVGString")>]
        static member toSVGString 
            (
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                fun (gChart:GenericChart) ->
                    gChart
                    |> Chart.toSVGStringAsync(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                    |> Async.RunSynchronously
            
        [<CompiledName("SaveSVGAsync")>]
        static member saveSVGAsync
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                let opts = RenderOptions(?EngineType=EngineType, ?Width=Width, ?Height=Height)
                
                fun (gChart:GenericChart) -> opts.Engine.SaveSVGAsync(path, opts.Width, opts.Height, gChart)
        
        [<CompiledName("SaveSVG")>]
        static member saveSVG
            (
                path: string,
                [<Optional;DefaultParameterValue(null)>] ?EngineType: ExportEngine,
                [<Optional;DefaultParameterValue(null)>] ?Width : int,
                [<Optional;DefaultParameterValue(null)>] ?Height : int
            ) = 
                fun (gChart:GenericChart) ->
                    gChart
                    |> Chart.saveSVGAsync(path, ?EngineType=EngineType, ?Width=Width, ?Height=Height)
                    |> Async.RunSynchronously