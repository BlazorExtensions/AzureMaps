import typescript from '@rollup/plugin-typescript';
import { nodeResolve } from '@rollup/plugin-node-resolve';
import path from "path";

export default {
  input: "src/BE.AzureMaps.ts",
  output: {
    dir: path.resolve(__dirname, '..', 'wwwroot'),
    format: 'es',
  },
  plugins: [typescript(), nodeResolve()]
};
