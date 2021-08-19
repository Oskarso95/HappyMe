const path = require('path')
const webpack = require('webpack')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const outputDir = './build'
const entry = './frontend/sass/index.scss'
const cssOutput = 'site.css'
const iconOutputDir = "./ClientResources/Editors/styles";


// var iconConfig = Object.assign({}, config, {
//     name: "icon",
//     entry: {
//         icon : [
//             __dirname + "/frontend/icons/*.css",
//     ]},
//     output: {
//        path: path.join(__dirname, iconOutputDir),
//        filename: "happy-me-icons.css"
//     },
// });

// var styleConfig = Object.assign({}, config,{
//     name: "index",
//     entry: {
//         index: [
//             __dirname + "/frontend/sass/index.scss",
//             __dirname + "/frontend/js/index.js",
//         ]
//     },
//     output: {
//         path: path.join(__dirname, iconOutputDir),
//         filename: "[name].js"
//      },
// }); 


// var config = {
//     module: {
//         rules: [
//             {
//                 test: /\.js$/,
//                 use: 'babel-loader'
//             },
//             {
//                 test: /\.css$/,
//                 use: [MiniCssExtractPlugin.loader, "css-loader"],
//             },
//             {
//                 test: /\.scss$/,
//                 use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"],
//             }
//         ]
//     },
//     plugins: [
//         new MiniCssExtractPlugin({
//             filename : cssOutput,
//         })
//     ]
// }

// module.exports = [
//     styleConfig, iconConfig,       
// ];

module.exports = (env) => {    
    return [{
        entry: {
            index: [
                __dirname + "/frontend/sass/index.scss",
                __dirname + "/frontend/js/index.js",
                __dirname + "/frontend/icons/happyme.css",
            ],
        },
        output: {
            path: path.join(__dirname, outputDir),
            filename: '[name].js',
            publicPath: '/build/'
        },
        module: {
            rules: [
                {
                    test: /\.js$/,
                    use: 'babel-loader'
                },
                {
                    test: /\.css$/,
                    use: [MiniCssExtractPlugin.loader, "css-loader"],
                },
                {
                    test: /\.scss$/,
                    use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"],
                }
            ]
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename : cssOutput,
            })
        ]
    }]
}