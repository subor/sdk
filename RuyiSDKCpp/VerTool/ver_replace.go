package main

import (
	"fmt"
	"io/ioutil"
	"os"
	"strings"
)

func main() {
	if len(os.Args) != 3 {
		fmt.Print("please provide version file and version number")
		return
	}
	params := os.Args[1:]

	v := "#pragma once \n\n"
	v += "#define BIN_VERSION " + strings.Replace(params[1], ".", ",", -1) + "\n\n"
	v += "#define STR_VERSION \"" + params[1] + "\"\n\n"

	err := ioutil.WriteFile(params[0], []byte(v), 0)
	if err != nil {
		panic(err)
	}

	fmt.Print("replace over!")
}
