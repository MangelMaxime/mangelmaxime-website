module Layouts

open Fable.Core.JsInterop
open Nacara.Core.Types
open Fable.React
open Fable.React.Props

// Your render function, it is responsible to transform a page into HTML
let render (rendererContext : RendererContext) (pageContext : PageContext) =
    promise {
        let! pageContent =
            rendererContext.MarkdownToHtml(
                pageContext.Content,
                pageContext.RelativePath
            )

        return Page.render
                    rendererContext
                    pageContext
                    null
    }

// This is how we expose layouts to Nacara
exportDefault
    {
        Renderers = [|
            {
                Name = "index"
                Func = render
            }
        |]
        Dependencies = [| |]
    }
