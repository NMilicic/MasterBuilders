//
//  MyBrick.swift
//  LegoApp
//
//  Created by Helena Tamburić on 29/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

//
//  Set.swift
//  LegoApp
//
//  Created by Helena Tamburić on 19/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import Foundation

import Unbox

struct MyBrick {
    let Id: Int
    let Ime: String
    let Kategorija: String
    let Slika: String
    
}

extension MyBrick: Unboxable {
    init(unboxer: Unboxer) throws {
        self.Id = try unboxer.unbox(key: "Id")
        self.Ime = try unboxer.unbox(key: "Name")
        self.Slika = try unboxer.unbox(key: "PictureUrl")
        self.Kategorija = try unboxer.unbox(keyPath: "Category.Name")
    }
}

