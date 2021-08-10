const path = require('path')
const webpack = require('webpack')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')

const outputDir = './build'
const entry = './frontend/sass/index.scss'
const cssOutput = 'site.css'

module.exports = (env) => {    
    return [{
        entry: {
            index: [
                __dirname + "/frontend/sass/index.scss",
                __dirname + "/frontend/js/index.js"
            ]
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