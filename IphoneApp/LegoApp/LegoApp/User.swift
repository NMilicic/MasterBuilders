//
//  User.swift
//  LegoApp
//
//  Created by Helena Tamburić on 17/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import Foundation

import Unbox

struct User {
    let id : Int
    let ime: String
    let prezime : String
    let zaporka: String
    let email: String
    
}

extension User: Unboxable {
    init(unboxer: Unboxer) throws {
        self.id = try unboxer.unbox(key: "Id")
        self.ime = try unboxer.unbox(key: "FirstName")
        self.zaporka = try unboxer.unbox(key: "Password")
        self.email = try unboxer.unbox(key: "Email")
        self.prezime=try unboxer.unbox(key: "LastName")
    }
}
