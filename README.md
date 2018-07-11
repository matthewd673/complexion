# Complexion

## What is it?

Complexion is a barebones programming language that I designed as a kid. I recently found a text file on my old laptop detailing (what I suspect is an incomplete) version of complexion.

## Running

By opening the project in Visual Studio Code and running it the file `test.complexion` will be ran. You can run your own files by editing `launch.json` just like any other VSCode project.

## Restrictions

Complexion consists of only a few characters (partially expanded from the original list to make the language more functional). It can open one file at a time and read any integer contained in it.
In addition to holding the value stored inside the file, it can hold one other integer value at any given time and modify it with a few basic commands. This integer value must be greater than zero and can be outputted to a specified file.

## Writing

| *Command*  | *Meaning*                                                                       |
|------------|---------------------------------------------------------------------------------|
| ^ [file]   | Open [file]                                                                     |
| _          | Close currently open file                                                       |
| > [number] | Add 1 to current value, or set current value to [number] + 1 if provided        |
| < [number] | Subtract 1 from current value, or set current value to [number] - 1 if provided |
| = [number] | Set current value equal to number                                               |
| . [file]   | Write to [file] **(not part of original design)**                               |
| $          | Value contained in current file **(not part of original design)**               |

## Annotated example

**Line**|** Meaning**
:-----:|:-----:
^ 1.txt| Open file `1.txt`
= $| Set current value equal to value of `1.txt`
\_| Close `1.txt`
>| Increment current value
^ 2.txt| Open file `2.txt` (it does not need to exist since we are not reading its value)
.| Write current value to `2.txt`
\_| Close `2.txt`
^ 3.txt| Open file `3.txt` (once again
< 80| Set current value to `80 - 1`
.| Write current value to `3.txt`
\_| Close `3.txt`