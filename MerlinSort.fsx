let stalinSort xs =
    let rec sort sorted trash xs =
        match xs, sorted with
        | x::tl, y::_ -> if y <= x
                         then sort (x::sorted) trash tl
                         else sort sorted (x::trash) tl
        | x::tl, _ -> sort (x::sorted) trash tl
        | _ -> (List.rev sorted, List.rev trash)

    sort [] [] xs

let merge xs ys =
    let rec loop acc xs ys =
        match xs, ys with
        | x::xs', y::ys' -> if x <= y
                            then loop (x::acc) xs' (y::ys')
                            else loop (y::acc) (x::xs') ys'
        | tl, [] | [], tl -> (List.rev acc) @ tl

    loop [] xs ys

let merlinSort xs =
    let rec sort acc = function
        | [] -> acc
        | xs -> let good, bad = stalinSort xs
                sort (good::acc) bad

    sort [] xs |> List.reduce merge
