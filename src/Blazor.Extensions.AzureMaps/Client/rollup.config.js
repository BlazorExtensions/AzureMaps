import typescript from "@rollup/plugin-typescript";
import { nodeResolve } from "@rollup/plugin-node-resolve";
import externals from "rollup-plugin-node-externals";
import commonjs from "@rollup/plugin-commonjs";
import path from "path";

const extensions = [".js", ".ts", ".tsx"];

export default {
  input: "src/BE.AzureMaps.ts",
  output: {
    dir: path.resolve(__dirname, "..", "wwwroot"),
    format: "es",
  },
  plugins: [
    externals({ peerDeps: true, deps: true, exclude: "azure-maps-control" }),
    nodeResolve({
      browser: true,
      extensions,
    }),
    commonjs(),
    typescript(),
  ],
};
