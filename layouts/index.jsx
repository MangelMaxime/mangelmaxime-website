// We need to import React for JSX to works
import React from "react";
import Page from "./components/Page";

console.log(Page);

/**
 * Include live-reload.js script when in watch mode
 */
const LiveReloadScript = ({ rendererContext }) => {
    if (rendererContext.Config.IsWatch) {
        const scriptSrc =
            rendererContext.Config.SiteMetadata.BaseUrl + "resources/nacara/scripts/live-reload.js";

        return <script async src={scriptSrc}></script>
    } else {
        return null;
    }
}

const TagPlaceHolder = ({children}) => {
    return (
        <span className="tag lowercase">
            {children}
        </span>
    )
}

// generate random text
const randomText = () => {
    const lorem =
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum euismod, nisl sit amet consectetur consectetur, nisi erat euismod nunc, eget consectetur nunc nisi eget consectetur. ";
    const words = lorem.split(" ");
    const randomWords = [];
    // random between 30 and 50
    const randomNumber = Math.floor(Math.random() * (60 - 30 + 1)) + 30;
    for (let i = 0; i < randomNumber; i++) {
        const randomIndex = Math.floor(Math.random() * words.length);
        randomWords.push(words[randomIndex]);
    }
    return randomWords.join(" ");
};

const GridPlaceHolder = () => {
    return (
        <a className="hover:cursor-pointer hover:bg-white p-8 rounded-lg hover:-translate-y-1 transition ease-linear duration-300 hover:shadow-2xl">
            <div className="text-center text-lg font-semibold">Getting started</div>
            <p className="pt-3 text-gray-500">
                {randomText()}
            </p>
            <div className="text-gray-500 text-sm mt-4">
                <div className="text-center">May 11, 2021</div>
                <div className="text-center mt-2">
                    <span className="mr-2">
                        <i className="fas fa-sm fa-tag"></i>
                    </span>
                    <div className="tags inline-block">
                        <TagPlaceHolder>F#</TagPlaceHolder>
                        <TagPlaceHolder>Elmish</TagPlaceHolder>
                        <TagPlaceHolder>Template</TagPlaceHolder>
                    </div>
                </div>
            </div>
        </a>
    )
}

// Your render function, this is where you will write all of your code
const render = async (rendererContext, pageContext) => {
    return (
        <html>
            <head>
                <meta charSet="UTF-8" />
                <meta name="viewport" content="width=device-width, initial-scale=1.0" />
                <link href="/style.css" rel="stylesheet" />
                <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
                <title>{pageContext.title}</title>
            </head>
            <body className="flex flex-col bg-gray-100 font-serif">
                <div className="py-8 z-10">
                    <div className="container px-6">
                        <div className="flex items-center justify-between">
                            <div className="text-2xl" >Fable Adventure</div>
                        </div>
                    </div>
                </div>

                <div className="container px-4 lg:px-0 max-w-screen-lg">
                    <div className="grid grid-flow-row grid-cols-1 md:grid-cols-2 gap-4">
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                        <GridPlaceHolder></GridPlaceHolder>
                    </div>
                </div>

                <div className="flex-shrink-0 h-32 mt-4 bg-gray-800">
                    <div className="container text-center text-white">
                            © 2021 Copyright by Mangel Maxime . All rights reserved.
                    </div>
                </div>

                <LiveReloadScript rendererContext={rendererContext} />
            </body>
        </html>
    )
}

export default {
    // List of the renderers
    // For now, we will have only one renderer
    Renderers: [
        {
            // Name of your layout, this is what you write in the front-matter
            // Example:
            // ---
            // layout: my-layout
            // ---
            Name: "index",
            Func: render
        }
    ],
    // List of the static file to copy into the build directory
    // For example, if your layout need a `menu.js`
    Dependencies: []
}
